%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Leaf Box - RGB processing %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% JF %
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

clear all
close all 
clc

runMode = input('Select the appropriate response to continue:\n  (1) Select image files to process (one or many) \n  (2) Select a single folder and process all images.\n  (3) Select the parent "ExpID-Originals" folder to bulk process all files in the project\nSelect a number: ')
if isempty(runMode)
    runMode = 1;
end

if runMode == 1
    [FileName,PathName] = uigetfile('X:\a_data\TimeStreams\Atkins\BVZ0047\BVZ0047-originals\2015_05_22\*.jpg','MultiSelect','on','Select the Experiment root folder (The folder with the EXPID name)'); % set path to your images
elseif runMode == 2
    [FileName,PathName] = uigetdir('X:\a_data\TimeStreams\Atkins\BVZ0047\BVZ0047-originals\2015_05_22\*.jpg','MultiSelect','on','Select the Experiment root folder (The folder with the EXPID name)'); % set path to your images
elseif runMode == 3
    expRootPath = uigetdir('X:\a_data\TimeStreams\Atkins\BVZ0047\BVZ0047-originals\','Select the Experiment root folder (The folder with the EXPID name)'); % set path to your images
    expFolders = dir(expRootPath)
    %remove non-directories (i.e. '.' and '..' folder)
    expFolders = expFolders(arrayfun(@(expFolders) expFolders.name(1), expFolders) ~= '.')
    %Also remove anything with an underscore at the start of the name (this is how we flag folders to omit)
    expFolders = expFolders(arrayfun(@(expFolders) expFolders.name(1), expFolders) ~= '_')
    return
else
    beep
    disp('Response not recognized. Exiting program')
    return
end


--> After user has selected the files/folders, ask them if they want to save the output data 
--   Or maybe do this at the end?
    
--> Code needs to be restructured to support the different methods of loading files, 
--   but we just need to create the full filelist from any of the methods and 
--   pass it to the Filename/Pathname array

%[FileName,PathName] = uigetdir('X:\a_data\TimeStreams\Atkins\BVZ0047\BVZ0047-originals\2015_05_22\*.jpg','MultiSelect','on','Select the Experiment root folder (The folder with the EXPID name)'); % set path to your images
[FileName,PathName] = uigetfile('X:\a_data\TimeStreams\Atkins\BVZ0047\BVZ0047-originals\2015_05_22\*.jpg','MultiSelect','on','Select the Experiment root folder (The folder with the EXPID name)'); % set path to your images
ISC = iscell(FileName);
if ISC == 1
    N = length(FileName);
elseif ISC == 0
    A{1} = FileName;
    FileName = A;
    N = 1;
end
disp([num2str(N) ' images found'])

folderPath = strsplit(fileparts(PathName),'\');
expDate = folderPath(length(folderPath))
expID = folderPath(length(folderPath)-2) %This assumes the existing folder structure is maintained

for i = 1:N
    ['Now processing image ' num2str(i) ' of ' num2str(N)]
    tic;
    Img = im2double(imread([PathName FileName{i}]));    
    [height, width, channels] = size(Img);
    Img = imcrop(Img,[1 1 width height - 5]);
    [height, width, channels] = size(Img);
    figure
    subplot(2,1,1)
    imshow(Img)
    title('Original image')
   disp('.')
    
    gsImg = rgb2gray(1-Img);
    
    
    edgeImg = edge(gsImg,'sobel',0.02,'both');
    edgeImg = bwmorph(edgeImg,'dilate',1);
   disp('..')
    xlines = mean(edgeImg,1);
    ylines = mean(edgeImg,2);
    [Xpks Xlocs] = findpeaks(xlines(1:800),'minpeakheight',0.1);
    [Ypks Ylocs] = findpeaks(ylines(1:450),'minpeakheight',0.1);
    [XXlocs] = find(xlines(1400:width)> 0.5);
    [XXXlocs] = find(xlines(250:350)> 0.1); 
    MX = max(Xlocs);
    MY = max(Ylocs);
    Img(1:MY, 1:MX,:) = 0.8;
    Img(:,XXlocs+1399:end,:) = 0.8;
    Img(:,XXXlocs+249,:) = 0.8;
    disp('...')
    intImg = zeros(height,width,channels);

    intImg(:,:,1) = Img(:,:,1)./(Img(:,:,1)+Img(:,:,2)+Img(:,:,3));
    intImg(:,:,2) = Img(:,:,2)./(Img(:,:,1)+Img(:,:,2)+Img(:,:,3));
    intImg(:,:,3) = Img(:,:,3)./(Img(:,:,1)+Img(:,:,2)+Img(:,:,3));
    gImg = zeros(height, width);
    gImg(:,:) = (intImg(:,:,2) - intImg(:,:,3))./(intImg(:,:,2) + intImg(:,:,3));
    gImg = imfill(gImg,'holes'); 
    EImg = edge(gImg,'canny',[0.05 0.3]);
    EImg = bwmorph(EImg,'dilate',1);
    bwImg = im2bw(gImg,0.08);
    bwImg = imadd(bwImg,EImg);
    bwImg = imfill(bwImg,'holes');
    bwImg = bwmorph(bwImg,'bridge',Inf);
    bwImg = bwmorph(bwImg,'majority',Inf);
    bwImg = bwareaopen(bwImg,500);
    bwImg = bwmorph(bwImg,'thin',1);
    segmentedImg = zeros(height,width,channels);
    disp('....')
    for h = 1:height
        for w = 1:width
            if bwImg(h,w) == 1
                segmentedImg(h,w,:) = Img(h,w,:);
            end
        end
    end
    subplot(2,1,2)
    imshow(segmentedImg);
    title('Segmented Image');
    
    Stats = regionprops(bwImg,'all');
    % Need to make sure we didn't detect more than one shape
    % For now, let's grab the right-most shape and hope this selects the leaf (not rigorously tested)
    % Actually, I'll try just grabbing the item with the alrgest area and see if that works
    % Better way to do it would be to pick the object with more green pixels
    numObjs = length(Stats);
    if numObjs > 1
        disp('Multiple regions found, deleting smaller region');
        %Delete the output with the smaller area
        for i = 1:numObjs
            a(i) = Stats(i).Area;
        end
        %Replace Stats with just the larger value
        Stats = Stats(find(a == (max(a))));
    end
    
    
    Results{i}{1,1} = FileName{i};
    Results{i}{2,1} = 'Area';
    Results{i}{2,2} = Stats.Area;
    Results{i}{3,1} = 'Perimeter';
    Results{i}{3,2} = Stats.Perimeter;
    Results{i}{4,1} = 'Length';
    Results{i}{4,2} = Stats.BoundingBox(1,3);
    Results{i}{5,1} = 'Width';
    Results{i}{5,2} = Stats.BoundingBox(1,4);
    Results{i}{6,1} = 'Eccentricity';
    Results{i}{6,2} = Stats.Eccentricity;
    Results{i}{7,1} = 'Major Axis Length';
    Results{i}{7,2} = Stats.MajorAxisLength;
    Results{i}{8,1} = 'Minor Axis Length';
    Results{i}{8,2} = Stats.MinorAxisLength;
    Results{i}{9,1} = 'Bounding Box Area / Area';
    Results{i}{9,2} = Stats.Extent;

    Name = textscan(FileName{i},'%s','delimiter','j');
    imwrite(segmentedImg, [PathName Name{1,1}{1,1} 'SEG.png'],'png');
    toc/60
end

return
%Save results
for i = 1:N
    xlswrite([PathName Name{1,1}{1,1} 'xlsx'], Results{i});
end


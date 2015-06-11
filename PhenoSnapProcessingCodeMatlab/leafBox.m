%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Leaf Box - RGB processing %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% JF %
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

clear all
close all 
clc

[FileName,PathName] = uigetfile('D:\PSI\Tim\2015_05_22\*.jpg','MultiSelect','on','Select the RGB image'); % set path to your images
ISC = iscell(FileName);
if ISC == 1
    N = length(FileName);
elseif ISC == 0
    A{1} = FileName;
    FileName = A;
    N = 1;
end

for i = 1:N
    Img = im2double(imread([PathName FileName{i}]));    
    [height, width, channels] = size(Img);
    Img = imcrop(Img,[1 1 width height - 5]);
    [height, width, channels] = size(Img);
    figure
    subplot(2,1,1)
    imshow(Img)
    title('Original image')
    
    gsImg = rgb2gray(1-Img);
    
    
    edgeImg = edge(gsImg,'sobel',0.02,'both');
    edgeImg = bwmorph(edgeImg,'dilate',1);
   
    xlines = mean(edgeImg,1);
    ylines = mean(edgeImg,2);
    [Xpks Xlocs] = findpeaks(xlines(1:800),'minpeakheight',0.1);
    [Ypks Ylocs] = findpeaks(ylines(1:450),'minpeakheight',0.1);
    [XXlocs] = find(xlines(1400:width)> 0.4);
    [XXXlocs] = find(xlines(250:350)> 0.1); 
    MX = max(Xlocs);
    MY = max(Ylocs);
    Img(1:MY, 1:MX,:) = 0.8;
    Img(:,XXlocs+1399:end,:) = 0.8;
    Img(:,XXXlocs+249,:) = 0.8;
    
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
    
    Results{1,1} = FileName{i};
    Results{2,1} = 'Area';
    Results{2,2} = Stats.Area;
    Results{3,1} = 'Perimeter';
    Results{3,2} = Stats.Perimeter;
    Results{4,1} = 'Length';
    Results{4,2} = Stats.BoundingBox(1,3);
    Results{5,1} = 'Width';
    Results{5,2} = Stats.BoundingBox(1,4);
    Results{6,1} = 'Eccentricity';
    Results{6,2} = Stats.Eccentricity;
    Results{7,1} = 'Major Axis Length';
    Results{7,2} = Stats.MajorAxisLength;
    Results{8,1} = 'Minor Axis Length';
    Results{8,2} = Stats.MinorAxisLength;
    Results{9,1} = 'Bounding Box Area / Area';
    Results{9,2} = Stats.Extent;

    Name = textscan(FileName{i},'%s','delimiter','j');

    xlswrite([PathName Name{1,1}{1,1} 'xlsx'], Results);
    imwrite(segmentedImg, [PathName Name{1,1}{1,1} 'SEG.png'],'png');
end
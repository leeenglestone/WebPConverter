# WebPConverter
Local WebP Image Format Converter Console Application in C# and .NET

## Description
I was looking for a way to convert a number of png and jpg files to webP format. I couldn't find an ideal solution so put this code together.

I hope you find it useful.

It allows you to just drag an image into a folder and a webp version of the image be created.

## Usage
When you run the Console Application it monitors a folder location for new png or jpg images using a FileSystemWatcher.

If it detects a newly created png or jpg it converts it to a webp image.

## NuGet Dependencies
- ImageProcessor
- ImageProcessor.Plugins.WebP

## Configurable variables
- _watchFolderPath (Change this to the folder you want to monitor for new images)
- _imageQualityPercentage (The percentage quality that you want the WebP to be output with. By default this is 80%)

## License
[MIT](https://choosealicense.com/licenses/mit/)
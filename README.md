# Genetic Image Regeneration
This application dynamically regenerates images by taking a genetic approach to image creation. Essentially, we generate a large group of children which are rectangles with a color value. Each of those rectangles gets placed on to a blank image and scored based on how closely the new image resembles the old image. The top scoring child gets to live and be permenatly placed on the new image then a new generation gets generated. Repeat this pattern and eventually we will regenerate the source image.

## Example
If we take a 200x200 image and generate 2000 generations with 1000 children (2000x1000) in each generation. We can roughly get an image with a 94% accuracy to the source image. Theoretically we can completely regenerate the source image given enough generations.

| Source             |  Result (2000x1000) | Process GIF (500x500) |
:-------------------------:|:-------------------------:|:-------------------------:|
![Source Image](https://github.com/Karrotts/GeneticRegeneration/blob/main/imgs/test.jpg "Source Image of Homer Simpson")  |  ![Result Image](https://github.com/Karrotts/GeneticRegeneration/blob/main/imgs/output.png "Result Image of Homer Simpson") | ![Result Image](https://github.com/Karrotts/GeneticRegeneration/blob/main/imgs/process.gif "Result Image of Homer Simpson")

## Usage 
Build the application and provide arguments for image path, generation count, children count, mutation count. Optionally you can provide arguments for exporting frames and generating report data.
```
GeneticRegeneration.exe IMAGE_PATH GENERATIONS CHILDREN MUTATIONS EXPORT_FRAMES REPORTS
```
**Example**
```
GeneticRegeneration.exe C:\dev\image\example.jpg 500 500 100 false true
```

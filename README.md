# Genetic Image Regeneration
This application dynamically regenerates images by taking a genetic approach to image creation. Essentially, we generate a large group of children which are rectangles with a color value. Each of those rectangles gets placed on to a blank image and scored based on how closely the new image resembles the old image. The top scoring child gets to live and be permenatly placed on the new image then a new generation gets generated. Repeat this pattern and eventually we will regenerate the source image.

## Example
If we take a 200x200 image and generate 2000 generations with 1000 children in each generation. We can roughly get an image with a 94% accuracy to the source image.

**Source:**

![Source Image](https://github.com/Karrotts/GeneticRegeneration/blob/main/imgs/test.jpg "Source Image of Homer Simpson")

**Result of 2000 generations, with 1000 children:**

![Result Image](https://github.com/Karrotts/GeneticRegeneration/blob/main/imgs/output.png "Result Image of Homer Simpson")

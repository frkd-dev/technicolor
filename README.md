# Technicolor #

Experiment to imitate old 2-strip and 3-strip technicolor films from regular RGB images. For simplicity of experiment code was written as C# plugins for Paint.NET editor, due to this there is no build or make files, just sources.

## Examples ##

Here are examples how algorithm works. Images are taken from Aviator movie wich emulated 2/3-strip technicolor film from conventional images in postproduction. Plugin and movie images are very close, but not identical, because movie colorists had used own proprietary LUTs (lookup tables) instead of pure algorithms and did some color grading.

### 2 strip ###

**Original shot**

![](images/2strip-original.jpg)

**Movie proprietary LUT**

![](images/2strip-movie.jpg)

**Plugin output**

![](images/2strip-plugin.jpg)

### 3 strip ###

**Original shot**

![](images/3strip-original.jpg)

**Movie proprietary LUT**

![](images/3strip-movie.jpg)

**Plugin output**

![](images/3strip-plugin.jpg)

# License

Use code under MIT license.
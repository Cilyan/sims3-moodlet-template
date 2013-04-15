Custom Moodlet Template
=======================

This project is a working template that demonstrates how to add a 
custom moodlet (Buff) to your Sims 3 Mod.

Putting the template on rails
-----------------------------

This project is almost ready to be used. You need however to redo
the references to the Sims assemblies. See this [tutorial][monodevtuto]
if you are not familiar with the procedure. Note that you will need
the *unprotected* version of `Sims3GameplaySystems.dll`.

Description of files
--------------------

* `Buffs.cs`: This file is a template showing you how to define your 
own Buff class. Real definition for your buff is in the associated 
XML file. Here you only define a skeleton.

* `Buffs.xml`: This is the file containing the real definition of 
the moodlet(s), the buff data. There are no human-readable text in 
this file, as name, description, etc. will be found in the STBL 
(language) file.

* `moodlet.png`: This is a sample icon for the moodlet. Must be 
32x32 (max 54x54 but doesn't scale down nicely).

* `Localisation.EN.xml`: This file contains the language definition, 
which is essential to any moodlet. It will be compiled into an STBL 
file using [stblc][]. You can't make a moodlet without associated 
STBL file.

* `Bootstrap.cs`: This file contains the BuffLoader class that will 
load moodlets from the Buffs.xml file. If you change the name of the 
buff definition XML file in your package, you have to adapt the 
class to load the right ressource. The file also contains a sample 
Bootloader that will activate the BuffLoader at the right moment 
(and also loads a demonstration interaction). Base your own 
bootloader on this sample class to integrate your moodlet in your 
code.

* `Bootloader.xml`: This XML file will make the Bootloader class be 
loaded in the Sims and hooks the whole script in the game when it 
try to load the "kInstantiator" parameter. This file is not really 
part of the template, you should have your own.

* `BuffTestInteraction.cs`: This file demonstrates the use of your 
new moodlet through a simple ImmediateInteraction placed by the 
Bootloader on any Sim.

* `moodlet.svg`: Vectorial source of the sample PNG icon. Don't pay 
attention.


Organisation of the .package
----------------------------

Once you compiled the project, there are some rules your have to follow
when creating your .package file (let's say using [S3PE][]):

* First, make sure that the name of your assembly matches the one
you specified in the `CustomClassName` tag of the `Buffs.xml` file.
The name of the assembly is specified in your project's properties.

* Put the `DLL` in the package with type `S3SA`. The name doesn't
matter.

* Put the `Buffs.xml` file in the package. The name must match the 
one you specified in the `BuffLoader` class. Type should be `_XML 
0x0333406C`.

* Put the icon file in the package. The name should match the one you
specified in the `ThumbFilename` tag of the `Buffs.xml` file. Type is
 `IMAG 0x2F7D0004`.

* Put the STBL file(s) you generated from the `Localisation.*.xml` in
the package. Name isn't important, but you have to modify the FNV hash
so that it starts with a specific number. Start with `0x00` for english,
 `0x07` for french, etc. See the list there: [How To Translate][nraas].

Save your .package and copy it to the modding directory of your Sims
installation and: enjoy!

[stblc]: https://github.com/Cilyan/stblc
[S3PE]:  http://www.den.simlogical.com/denforum/index.php?topic=189.0
[monodevtuto]: http://www.cilyan.org/misc/sims/monodevelop/XamarinTuto.html#step2
[nraas]: http://nraas.wikispaces.com/How+To+Translate#Languages

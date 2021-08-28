# DNA Computation

## Why would we need to compute DNA?
Computing DNA is a useful program since it can be interfaced with ideas such as [CRISPR](https://www.newscientist.com/definition/what-is-crispr/) which can be used to genetically modify DNA and cure people of terminal illnesses, allergies, and cancers.

## What is the point of this program?
This program is an open source system which can be directly modified or built on top of to create complex and useful tools for DNA manipulation. This program can be used for anything from scanning DNA to building it's polypeptide chains and seeing how different proteins are made with different DNA.

Another example of what you could use this program for is interfacing other hardwares to this program.
For example, say you had a machine which could read DNA, you could build on top of the Base6 system created and automatically be able to tell every single protein your body makes with a simple blood sample!

## How does it work?
### Note:
DNA is made up of 4 different nucleobases, and A LOT of them!
These 4 bases are Adenine (A), Cytosine (C), Guanine (G), and Thymine (T)

The order and construction of these nucleobases is what makes you, YOU!
We take 3 nucleobases at a time and convert them into Codons! Codons are then read by tRNA and their respective Amino Acids click into place with those 3 mRNA nucleobases and form a protein!
More and more of these proteins click together and form the Polypeptide Chain! This then folds and makes your protein which is used for various different cases from your immune system to building blocks!

With DNA being such a large and complex subject, getting it to be stored in computer memory can be tricky.
To simplify this, I created a Base6 system which this runs off of. For every byte there are 8 bits (0000 0000) and this program will take advantage of 6 of those 8 bits and reserve them to one codon (3 bases)

With numerous bitwise operations, we can follow this chart (In binary):
#### DNA
00 - Adenine

01 - Cytosine

10 - Guanine

11 - Thymine

#### mRNA
00 - Uracil

01 - Guanine

10 - Cytosine

11 - Adenine

#### Example
Byte: 01001101
Split up: 01 00 11 01
Convert with table (DNA):  Cytosine, Adenine, Thymine, Cytosine (CATC)
Cast enums for mRNA (mRNA): Guanine, Uracil, Adenine, Guanine (GUAC)

We then take the first 6 bits of it, or the first 3 nucleobases, and follow the Amino Acid Conversion Chart.

When casting from enum mRNABases to DNABases, it will follow the base pair rule and for example, Adenine will turn into Uracil!

For mRNA (GUA) we get protein VALINE as printed from the application:

`GUANINE URACIL ADENINE - Resulting in protein VALINE`



For more information, feel free to read the source code or contact me!

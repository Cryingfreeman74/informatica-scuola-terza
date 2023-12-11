#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il nome del primo file: " file1
read -p "Inserisci il nome del secondo file: " file2
read -p "Inserisci il nome del file finale: " file3

file1=$file1.txt
file2=$file2.txt
file3=$file3.txt

touch $file1
touch $file2
touch $file3

echo ">1A34:A|PDBID|CHAIN|SEQUENCE
MGRGKVKPNRKSTGDNSNVVTMIRAGSYPANTONIOKVNPTPT
WVRAIPFEVSVQSGIAFKVPVGSLFSANFRTDSFTS
VTVMSVRAWTQLTPPVNEYSFVRLKPLFKTGDSTEE
FEGRASNINTRASVGYFDSFDSAOLMIDNDASL" >> $file1

echo "RIPTNLRQNTVAADNVCEVR FDSFFDF
SNCRANTIDILUVIANOQVALVISCCFN
>1A34:B|PDBID|CHAIN|SEQUENCE
AAAAAAAAAA
>1A34:C|PDBID|CHAIN|SEQUENCE
UUUUUUUUUUo" >> $file2

cat $file1 $file2 >> $file3

echo
file $file3
echo "--------------------------------"
cat $file3
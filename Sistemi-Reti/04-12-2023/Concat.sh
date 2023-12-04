#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il nome del primo file: " file1
read -p "Inserisci il nome del secondo file: " file2
read -p "Inserisci il nome del file finale: " file3

file1=$file1.txt
file2=$file2.txt
file3=$file3.txt

touch $file1
touch "file2.txt"

echo ">1A34:A|PDBID|CHAIN|SEQUENCE" >> $file1
echo "MGRGKVKPNRKSTGDNSNVVTMIRAGSYPANTONIOKVNPTPT" >> $file1
echo "WVRAIPFEVSVQSGIAFKVPVGSLFSANFRTDSFTS" >> $file1
echo "VTVMSVRAWTQLTPPVNEYSFVRLKPLFKTGDSTEE" >> $file1
echo "FEGRASNINTRASVGYFDSFDSAOLMIDNDASL" >> $file1

echo "RIPTNLRQNTVAADNVCEVR FDSFFDF" >> $file2
echo "SNCRANTIDILUVIANOQVALVISCCFN" >> $file2
echo ">1A34:B|PDBID|CHAIN|SEQUENCE" >> $file2
echo "AAAAAAAAAA" >> $file2
echo ">1A34:C|PDBID|CHAIN|SEQUENCE" >> $file2
echo "UUUUUUUUUUo" >> $file2

cat $file2 $file2 >> $file3

cat $file3
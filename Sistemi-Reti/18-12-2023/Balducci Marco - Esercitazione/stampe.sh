#!/bin/bash
#Balducci Marco 3H

read -p "Inserisci il nome del primo file: " file1
read -p "Inserisci il nome del secondo file, diverso dal primo: " file2

file1=$file1.txt
file2=$file2.txt

echo "Dashing through the snow In a one-horse open sleigh
O'er the fields we go Laughing all the way
Bells on bobtails ring Making spirits bright
What fun it is to ride and sing A sleighing song tonight" > $file1

echo "Jingle bells, jingle bells Jingle all the way
Oh, what fun it is to ride In a one-horse open sleigh, hey
Jingle bells, jingle bells Jingle all the way
Oh, what fun it is to ride In a one-horse open sleigh" > $file2

cat $file1 $file2 > canzone.txt

echo "
Righe contententi ride:"
echo "---------------------------"
grep "ride" canzone.txt
echo "---------------------------
"
echo "Righe non contenenti horse:"
echo "---------------------------"
grep -v "horse" canzone.txt
echo "---------------------------
"

read -p "Inserisci il nome del file in cui inserire la quinta riga in ordine alfabetico della canzone: " file_finale
sort canzone.txt | head -5 | tail -1 > $file_finale.txt
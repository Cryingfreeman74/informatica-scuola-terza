#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il nome del file contenente i voti degli studenti: " file
read -p "inserisci il numero degli studenti: " Num_studenti

file=$file.txt

for ((i=0; i<$Num_studenti; i++))
do
    read -p "Inserisci il nome dello studente numero $(($i+1)): " studente
    read -p "inserisci ora il suo voto: " voto

    echo "$studente $voto" >> $file
done

echo "
Ordine Alfabetico crescente
-----------------------------"
sort $file
echo "-----------------------------
"

echo "Ordine Alfabetico decrescente
-----------------------------"
sort -r $file
echo "-----------------------------
"
sort $file -o elenco_crescente.txt

sort -r $file -o elenco_decrescente.txt

sort -k2 -n $file -o elenco_voto.txt

#Fase 2
echo "Fase 2"
sort $file | head -2 | tail -1 > nominativo.txt
echo "file nominativo.txt generato con successo"
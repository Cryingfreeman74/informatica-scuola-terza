#!/bin/bash
#Marco Balducci 3H

read -p "inserisci il numero di file da generare: " numero_file

mkdir -p cartella_di_lavoro
cp ./fileGenerator.sh ./cartella_di_lavoro
cd cartella_di_lavoro

for ((i=0; i<$numero_file; i++))
do
    ./fileGenerator.sh
done

rm fileGenerator.sh

echo "
Ultimo file in ordine alfabetico:
--------------------------"
ls | tail -1
echo "--------------------------"

echo "
File in ordine di dimensione crescente:
--------------------------"
ls -la |sort -k5 -n
echo "--------------------------"
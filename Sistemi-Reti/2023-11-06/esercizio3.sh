#!/bin/bash
mkdir -p esercitazione3 #cartella generale, -p indica che se è già presente il comando viene saltato
cd esercitazione3 #mi sposto dentro

mkdir -p sorgente
cd sorgente 
touch prova.txt
cd ..
mkdir -p destinazione

echo "cartelle generate"

cp -f sorgente/prova.txt destinazione/provacopiata.txt #copio e sposto il file, -f indica che se il file è già presente questo verrà sovrascritto
echo "file copiato e spostato"
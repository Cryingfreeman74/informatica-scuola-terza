#!/bin/bash
#Balducci Marco 3H

read -p "Inserisci il nome della cartella da generare: " nome_directory
mkdir -p $nome_directory

cd $nome_directory

numeroFile=$(($RANDOM % 6 + 4)) #genero un numero da 0 a 5 e poi aggiungo 4

for ((i=1; i<=$numeroFile; i++))
do
    touch verifica$i.txt
done
#!/bin/bash
#Balducci Marco 3H

read -p "Inserisci il numero di cui stampare la tabellina: " numero

for ((i=1; i<=10; i++))
do
    echo "$(($numero*$i))"
done
#!/bin/bash
#Marco Balducci 3H

read -p "inserisci il numero da verificare: " numero
primo=1 #1 se primo, 0 se non primo

for ((i=2; i<$numero; i++))
do
    if (($numero % i == 0));
    then primo=0
    fi 
done

if [ $primo -eq 1 ];
then echo "Il numero è primo"
else echo "Il numero non è primo"
fi
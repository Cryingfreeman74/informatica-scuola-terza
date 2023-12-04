#!/bin/bash
#Marco Balducci 3H

read -p "Quanti lanci desidera fare?" lanci
for ((i=1; i<=$lanci; i++))
do
    esito1=$(($RANDOM % 6 + 1))
    esito2=$(($RANDOM % 6 + 1))

    risultato=$(($esito1+$esito2))
    echo "Risultato $i: " $risultato 
done

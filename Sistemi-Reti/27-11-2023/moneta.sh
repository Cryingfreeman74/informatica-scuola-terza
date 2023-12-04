#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il numero di lanci da effettuare: " lanci

for ((i=1; i<=lanci; i++))
do
    esito=$(($RANDOM%2))
    if [ $esito -eq 1 ];
        then echo "è uscita testa"
    else 
        echo "è uscita croce"
    fi
done
    
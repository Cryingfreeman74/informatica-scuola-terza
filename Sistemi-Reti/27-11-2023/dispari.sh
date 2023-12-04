#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il limite (non compreso): " LIMITE

for ((i=0; i<LIMITE; i++))
do
    if ((i%2!=0)); then
        echo $i
    fi
done
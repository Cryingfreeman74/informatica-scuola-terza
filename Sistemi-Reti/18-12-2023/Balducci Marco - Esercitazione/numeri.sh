#!/bin/bash
#Balducci Marco 3H

read -p "Inserisci il limite fino a cui stampare numeri: " limite

if (($limite < 0));
    then echo "limite non accettabile, deve essere positivo oppure zero."
else
    contatore=0
    while (($contatore <= $limite))
    do
        echo "$contatore"
        contatore=$(($contatore+1))
    done
fi
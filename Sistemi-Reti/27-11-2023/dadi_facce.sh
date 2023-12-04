#!/bin/bash
#Marco balducci 3H
#Questo script si differenzia dall'altra versione di dadi perchè all'utente vengono richieste in input le facce del dado ed il numero dei dadi

read -p "Quanti lanci vuoi fare: " lanci
read -p "Quante facce vuole per ogni dado: " facce
read -p "Quanti dadi vuole lanciare alla volta: " dadi

if (($facce > 0 && $dadi > 0));
then 
    for ((i=1; i<=lanci; i++))
    do
        somma=0
        esito=0

        for ((j=0; j<dadi; j++))
        do
            esito=$(($RANDOM % $facce + 1))
            let "somma+=$esito"
        done
        echo "Risulato lancio $i: $somma"
    done
else echo "Non si può tirare meno di un dado oppure dadi con meno di una faccia"
fi
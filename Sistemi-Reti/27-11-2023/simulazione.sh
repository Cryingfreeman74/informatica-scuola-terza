#!/bin/bash
#Marco Balducci 3H

read -p "Premi 1 per tirare delle monete oppure premi 2 per tirare dei dadi: " scelta

case $scelta in
"1")
read -p "Inserisci il numero delle monete da lanciare" monete
for ((i=0; i<monete; i++))
do
    esito=$(($RANDOM%2))
    if [ $esito -eq 1 ];
        then echo "è uscita testa"
    else 
        echo "è uscita croce"
    fi
done
;;
"2")
read -p "inserisci il numero delle volte da lanciare i dadi" volte
for ((i=0; i<volte; i++))
do
    esito1=$(($RANDOM % 6 + 1))
    esito2=$(($RANDOM % 6 + 1))

    risultato=$(($esito1+$esito2))
    echo "Risultato: " $risultato 
done
;;

*)
echo "Non valido"
;;
esac
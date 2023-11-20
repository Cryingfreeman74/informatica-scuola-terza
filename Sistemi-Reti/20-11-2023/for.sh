#!/bin/bash
# for arg in [lista]
# lista rappresenta l'insieme dei possibili valori gestiti dal ciclo
# arg rappresenta l'argomento che passiamo alla variabile, cioè assume il valore
# di ognuna della variabili rappresentate nella lista

# sintassi standard
echo "Bene bambini, impariamo a contare fino a 5"
for i in 1 2 3 4 5
do
    echo "Numero $i"
done

# sintassi stile C
LIMITE=10
echo "Bene bambini, impariamo a contare fino a 5 in stile C"

for ((i=1; i<=LIMITE; i++))
do
    #....
done
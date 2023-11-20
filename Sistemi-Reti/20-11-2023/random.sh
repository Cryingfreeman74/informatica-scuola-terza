#!/bin/bash
# $RANDOM restituisce un intero casuaòe diverso ad ogni chiamata.
# Intervallo nominale: 0 - 32767
# Generare 10 numeri casuali fra 0 e 9

NUM_MASSIMO=10
CICLI=10
contatore=1

echo
echo "$NUM_MASSIMO numeri casuali"
echo "---------------------------"

while [ "$contatore" -le $CICLI ]
do
    numero=$RANDOM
    numero=$(($numero%$NUM_MASSIMO)) #casting, uso il moduo per ottenere sempre un numero < di 10
    echo "valore estratto: $numero"
    # contatore=$(($contatore+1)) #equivalente a quella sotto
    let "contatore+=1" #permette di eseguire dei calcoli
done
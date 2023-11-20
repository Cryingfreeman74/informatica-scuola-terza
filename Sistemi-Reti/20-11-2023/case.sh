#!/bin/bash

echo "Scegli un'opzione dalle seguenti:"
echo "1 per stampare il tuo nome"
echo "2 per stampare come ti chiamano"
echo "3 per stampare il nome del tuo animale"

read scelta
WORD=""

case $scelta in
    "1")
    read -p "Inserisci il tuo nome: " WORD
    echo "Il tuo nome è $WORD"
    ;;
    "2")
    read -p "Inserisci come ti chiamano: " WORD
    echo "Ti chiamano $WORD"
    ;;
    "3")
    read -p "Inserisci il nome del tuo animale: " WORD
    echo "Il nome del tuo animale è $WORD"
    ;;
    *) #valore di default che si assume per tutti gli altri valori
    echo "Opzione non valida"
    ;;
esac

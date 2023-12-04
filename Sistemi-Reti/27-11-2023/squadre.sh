#!/bin/bash
#Marco Balducci 3H

read -p "Premi qualsiasi tasto per lanciare il dado: " tasto

valoreUscito=$(($RANDOM%6+1)) #ottengo un numero casuale da 0 a 6

echo -e "È uscito il valore $valoreUscito"

case $valoreUscito in
    "1") 
    echo "Sei stato assegnato alla squadra Rossa"
    ;;
    "2") 
    echo "Sei stato assegnato alla squadra Verde"
    ;;
    "3") 
    echo "Sei stato assegnato alla squadra Gialla"
    ;;
    "4")
    echo "Sei stato assegnato alla squadra Blu"
    ;;
    "5") 
    echo "Sei stato assegnato alla squadra Rosa"
    ;;
    "6") 
    echo "Sei stato assegnato alla squadra Nera"
    ;;
esac
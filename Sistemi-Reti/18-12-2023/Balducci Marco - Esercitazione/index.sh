#!/bin/bash
#Balducci Marco 3H

#Menù per accedere agli script creati

continua=1
while [ $continua -eq 1 ]
do
    continua=0
    read -p "Che cosa vuoi fare:
    [1] tabellina.sh
    [2] numeri.sh
    [3] directory.sh
    [4] stampe.sh
    [5] ordinamento.sh
    " scelta

    case $scelta in
    "1")
        ./tabellina.sh
    ;;
    "2")
        ./numeri.sh
    ;;
    "3")
        ./directory.sh
    ;;
    "4")
        ./stampe.sh
    ;;
    "5")
        ./ordinamento.sh
    ;;
    *)
        echo "Scelta non valida, riprova."
        continua=1
    ;;
    esac
done
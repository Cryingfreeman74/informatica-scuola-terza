#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci il nome del file da generare: " nomefile
nomefile=$nomefile.txt

touch $nomefile

echo "File creato con successo"

continua=1
while [ $continua -eq 1 ]
do
    read -p "Inserisci 1 per inserire una nuova riga oppure 2 per uscire dall'editor: " scelta

    case $scelta in
    "1")
    read -p "Inserisci la stringa da inserire: " stringa
    echo $stringa >> $nomefile
    echo
    echo "----------------------------------------------------"
    echo "Contenuto file:"
    cat $nomefile
    echo "----------------------------------------------------"
    echo
    ;;
    "2")
    let "continua=0"
    ;;
    *)
    echo "Scelta non valida"
    ;;
    esac
done

echo 
echo "--Ricerca--"
echo "Mnb -------"
grep '[MnB]' $nomefile
echo "-----------"
echo "Numeri ----"
grep '[0-9]' $nomefile
echo "-----------"
echo "prova -----"
grep -v 'prova' $nomefile
echo "-----------"
echo "Maiuscole -"
grep '[A-Z]' $nomefile
echo "-----------"

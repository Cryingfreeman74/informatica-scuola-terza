#!/bin/bash
#Marco Balducci 3H

read -p "Inserisci quante cifre della sequenza di Fibonacci vuoi stampare: " limite

val1=0
val2=1

for ((i=1; i<limite; i++))
do
    if [ $i -eq 1 ]; then
        echo 1
    fi  
    sum=$(($val1+$val2))
    echo $sum
    val1=$val2
    val2=$sum
done
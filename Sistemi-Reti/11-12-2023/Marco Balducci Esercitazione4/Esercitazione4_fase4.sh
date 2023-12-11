#!/bin/bash
#Marco Balducci 3H

mkdir -p fase4
cd fase4

touch lab.txt
touch lab1.txt
touch lab2.txt
touch lso.txt
touch pluto.txt
touch prova.txt

cd ..
ls fase4 | grep -v "pluto.txt"| tail -3  | head -1
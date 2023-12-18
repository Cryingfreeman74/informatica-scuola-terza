#!/bin/bash
#Balducci Marco 3H

echo "File presenti nella cartella di lavoro: 
---------------------------------------------"
ls
echo "---------------------------------------------"

ls -l | grep -v "total " | sort -r -k5 -n | grep -v "ordinamento.txt" | tail -3 | head -1 > ordinamento.txt
echo "File ordinamento.txt generato con successo."
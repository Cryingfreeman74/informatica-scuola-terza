#!/bin/bash

#pipeline di due o più comandi
#operatore pipe = |
#permette di rendere l'output di un comando l'input di un altro

touch file1.txt
cat file1.txt | wc -l #alla fine vedrò nella console solo l'output dell'ultimo comando
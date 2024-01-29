; Marco Balducci 3H
; programma che calcola la divisione 15 / 4
name "esercizio 4"

.model small

.data
X DB 0fh
Y DB 04h
divisione DB ?
resto DB ?

.code
.startup
mov al, X
mov bl, Y
div bl ;div divide al per bl e inserisce il risultato in al, mentre il resto in ah
mov divisione, al
mov resto, ah                        
int 20h
.exit
END
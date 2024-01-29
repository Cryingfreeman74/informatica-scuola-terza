; Marco Balducci 3H
; programma di prova per shl ed shr

name "prova shift"
.model small

.data

.code
.startup
mov AX, 1
shl AX, 1
shr AX, 1
.exit
END
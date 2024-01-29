; Marco Balducci 3H
; W = X^2 + 4X con X=2
name "esercizio 5"

.model small

.stack

.data

X DW 2
W DW ?

.code
.startup
mov AX, X
push AX
mul AX     ; W = X^2

pop BX
shl BX, 2

add AX, BX ; W = X^2 + 4X

mov W, AX
int 20h

.exit
END

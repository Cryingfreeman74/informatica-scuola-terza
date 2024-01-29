; Marco Balducci 3H
; Y = 4X^3 - 3X^2 + 2X + 7
name "Esercizio 2 stack, push, pop"

.model small

.stack

.data

X DW 25
Y DW ?

.code
.startup

mov AX, X
mul X
mul X           ; Y = X^3

shl AX, 2       ; Y = 4X^3

push AX

mov AX, X
mul AX   
shl AX, 2
sub AX, X
mov BX, AX
pop AX
sub AX, BX      ; Y = 4X^3 - 3X^2

mov BX, X
shl BX, 1
add AX, BX      ; Y = 4X^3 - 3X^2 + 2X

add AX, 7       ; Y = 4X^3 - 3X^2 + 2X + 7

mov Y, AX
int 20h
.exit
END
; Marco Balducci 3H
; Y = 15X^4 - 8X^3 + 9X^2 - 5X +7
name "esercizio 3"

.model small

.stack

.data

x DW 5                                            

.code
.startup

mov ax, 7
push ax   ; calcolo 7

mov ax, x
shl ax, 2
add ax, x
push ax   ; calcolo 5X

mov ax, x
shl ax, 3
add ax, x
mul x
push ax   ; calcolo 9X^2

mov ax, x
mul x
mul x
shl ax, 3
push ax   ; calcolo 8X^3

mov ax, x
shl ax, 4
sub ax, x
mul x
mul x
mul x ; calcolo 15X^4

mov x, ax ; Y = 15X^4

pop ax
sub x, ax ; Y = 15X^4 - 8X^3

pop ax
add x, ax ; Y = 15X^4 - 8X^3 + 9X^2

pop ax
sub x, ax ; Y = 15X^4 - 8X^3 + 9X^2 - 5X

pop ax
add x, ax ; Y = 15X^4 - 8X^3 + 9X^2 - 5X + 7

int 20h

.exit
END
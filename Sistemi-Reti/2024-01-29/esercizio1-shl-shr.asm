;Marco Balducci 3H
;esercizio dove viene utilizzato shl invece che mul eccetto nel quadrato di X
name "esercizio shift" ; y = 8X^2 + 12X+ 32
.model small
.data
X DW 2
Y DW ?

.code
.startup
mov AX, X
mul AX     ; Y = X^2

shl AX, 3  ; Y = 8X^2

mov BX, X
shl BX, 3
add AX, BX ; Y = 8X^2 + 8X

shr BX, 1
add AX, BX ; Y = 8X^2 + 12X

mov BX, 1
shl BX, 5
add AX, BX ; Y = 8X^2 + 12X + 32

mov Y, AX

int 20h
.exit
END




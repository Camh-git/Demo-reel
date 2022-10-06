org 00H

;MAIN PROGRAM

toggle:	 MOV P1, #01H	   ; move 00000001 to PORT1				
		 CALL delay        ; execute dalay
         MOV A, P1         ; move PORT1 value to accumulator						
		 CPL A		   	   ; complement PORT1 value
		 MOV P1, A	       ; move 11111110 to PORT1				
		 CALL delay        ; execute delay
						
         sjmp toggle					

;DELAY SUB-ROUTINE

delay:   MOV R5, #10       ; load register R5 with 10
third:	 MOV R6, #200      ; load register R6 with 200
second:	 MOV R7, #200      ; load register R7 with 200

		 DJNZ R7, $        ; decrement R7 till it is zero
 DJNZ R6, second   ; decrement R6 till it is zero
         DJNZ R5, third    ; decrement R5 till it is zero
         
         ret               ; go back to main program
END

CLR C
 MOV A,#4CH ;
 SUBB A,#6EH ;
 JNC NEXT ;
 CPL A ;
 INC A 

NEXT: MOV R1,A 
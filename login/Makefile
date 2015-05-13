CC = gcc
CFLAGS = -lmysqlclient -lm -lz
DEPS = header.h
OBJ = main.o utilities.o
 
%.o: %.c $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)
 
CES: $(OBJ)
	$(CC) -o $@ $^ $(CFLAGS)
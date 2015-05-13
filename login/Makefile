CC = gcc
CFLAGS = -lmysqlclient -lm -lz -I /usr/local/mysql/include -L /usr/local/mysql/lib
DEPS = header.h
OBJ = login.o utilities.o
 
%.o: %.c $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)
 
login: $(OBJ)
	$(CC) -o $@ $^ $(CFLAGS)

clean:	
	rm *.o login
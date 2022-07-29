class Clock(object):

    def _init_(self, hours=0, minutes=0, seconds=0):
        self.hours = hours
        self.minutes = minutes
        self.seconds = seconds

    def set(self, hours, minutes, seconds=0):
        self.hours = hours
        self.minutes = minutes
        self.seconds = seconds

    def tick(self):
        """ Time will be advanced by one second """
        if self.seconds >= 60:
            self.seconds = 0
            if self.minutes >=60:
                self.minutes = 0
                if self.hours >=24:
                    self.hours = 0
                else:
                    self.hours +=1
            else:
                self.minutes +=1
        else:
            self.seconds +=1

    def display(self):
        print(" Rolex Clock: %d:%d:%d " % (self.hours, self.minutes, self.seconds))

    def str(self):
        return "%2d:%2d:%2d" % (self.hours, self.minutes, self.seconds)

x = Clock()
print(x)

for i in range (696969):
    x.tick()
    print(x)# /End

require 'gosu'

MAX = 10
NUM = 4
DISK_HEIGHT = 10
DISK_WIDTH = 30
DISK_GAP = 20
TOWER_WIDTH = 120

class Disk
  attr_accessor :width, :clr
end

def main
  $towers = Array.new(3)
  $towers[0] = Array.new(MAX)
  $towers[1] = Array.new(MAX)
  $towers[2] = Array.new(MAX)

  initTowersAndDisks(NUM)

  puts "0. In initialize\n"
  print_terminal_image

  hanoi(NUM, 'A', 'C', 'B')
  sleep(1)
end

def get_index_for_letter(c)
  t = 0

  case c
  when 'A'
    t = 0
  when 'B'
    t = 1
  when 'C'
    t = 2
  end

  t
end

# returns a disk
def pop(c)
  i = 0
  t = 0
  new_disk = Disk.new

  t = get_index_for_letter(c)

  new_disk.width = 0
  new_disk.clr = Gosu::Color::WHITE

  i = MAX - 1
  while i >= 0
    if $towers[t][i].width > 0
      new_disk.width = $towers[t][i].width
      new_disk.clr = $towers[t][i].clr
      $towers[t][i].width = 0
      return new_disk
    end
    i -= 1
  end
  new_disk
end

def push(c, push_disk)
  i = 0
  t = 0

  t = get_index_for_letter(c)

  while i < MAX
    if $towers[t][i].width == 0
      $towers[t][i].width = push_disk.width
      $towers[t][i].clr = push_disk.clr
      return
    end
    i += 1
  end
end

def printTowersToTerminal
  int t = 0
  int d = 0

  while t < 3
    print("\nTower #{t}")
    d = 0
    while d < MAX
      print("Disk #{$towers[t][d].width}") if $towers[t][d].width > 0
      d += 1
    end
    t += 1
  end
  print("\n")
end

def print_terminal_image
  disk_count = MAX - 1
  print("\nPrinting Towers:\n")
  while disk_count >= 0
    print_disk_terminal($towers[0][disk_count])
    print_disk_terminal($towers[1][disk_count])
    print_disk_terminal($towers[2][disk_count])
    print("\n")
    disk_count -= 1
  end
  puts('A     B      C     ')
  print('Press enter to continue')
  gets
end

def print_disk_terminal(disk)
  case disk.width
  when 0
    image = '     '
  when 1
    image = '-    '
  when 2
    image = '--   '
  when 3
    image = '---  '
  when 4
    image = '---- '
  end
  print(image)
end

def print_tower(t)
  xoffset = 0
  yoffset = 0

  d = 0
  while d < MAX
    xoffset = (TOWER_WIDTH * t) + (t * DISK_GAP) if t > 0
    if $towers[t][d].width > 0
      yoffset = DISK_HEIGHT * (MAX - d)
      print_disk($towers[t][d].width, xoffset, yoffset, $towers[t][d].clr)
    end
    d += 1
  end
end

def print_tower_graphics
  t = 0

  while t < 3
    print_tower(t)
    t += 1
  end
  sleep(1)
end

def hanoi(nbr, s, d, a)
  temp = Disk.new

  if nbr == 1
    temp = pop(s)
    push(d, temp)
    print("\nmove Disk #{nbr} from peg #{s} to #{d}")
    print_terminal_image
    return
  end

  hanoi(nbr - 1, s, a, d)

  print("\nmove Disk #{nbr} from peg #{s} to #{d}")
  print_terminal_image
  temp = pop(s)
  push(d, temp)

  hanoi(nbr - 1, a, d, s)
end

def initTowersAndDisks(disk_count)
  d = 0
  t = 0

  while t < 3
    d = 0
    while d < MAX
      $towers[t][d] = Disk.new
      $towers[t][d].width = 0
      $towers[t][d].clr = Gosu::Color::BLUE
      d += 1
    end
    t += 1
  end

  d = 0
  while d < disk_count
    $towers[0][d].width = disk_count - d
    $towers[0][d].clr = Gosu::Color::BLUE
    d += 1
  end
end

main


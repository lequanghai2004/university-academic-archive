require_relative 'input_functions'

module Genre
  POP, CLASSIC, JAZZ, ROCK = *1..4
end

$genre_names = %w[Null Pop Classic Jazz Rock]
$albums = nil

class Album
  attr_accessor :title, :artist, :genre, :tracks

  def initialize(title, artist, genre, tracks)
    @title = title
    @artist = artist
    @genre = genre
    @tracks = tracks
  end
end

class Track
  attr_accessor :name, :location

  def initialize(name, location)
    @name = name
    @location = location
  end
end

def read_track(a_file)
  # complete this function
  # you need to create a Track here.
  name = a_file.gets.chomp
  location = a_file.gets.chomp
  Track.new(name, location)

  # fill in the missing code
end

def read_tracks(a_file)
  count = a_file.gets.to_i
  tracks = []
  count.times do
    track = read_track(a_file)
    tracks << track
  end
end

# def read_album(a_file)
#     a_file.gets
#     title=a_file.gets.chomp
#     artist=a_file.gets.chomp
#     genre= a_file.gets.chomp
#     tracks=read_tracks(a_file)
#     album = Album.new(title, artist, genre, tracks)
# 	return album
# end

def print_track(track)
  puts(track.name)
  puts(track.location)
end

def print_tracks(a_file)
  i = 0
  while i < $genre_names.length
    print_track(a_file)
    i += 1
  end
end

# Returns an array of tracks read from the given file
def main
  sylvain = false
  while sylvain == false
    puts "Main Menu:
1 Read in Albums
2 Display Albums
3 Select an Album to play
4 Update an existing Album
5 Exit the application
Please enter your choice:"

    select = gets.chomp
    puts
    case select
    when '1'
      a_file = File.new('albums.txt', 'r')
      track = read_tracks(a_file)
      a_file.close
      puts 'Reading done'
    when '2'
      print_tracks(track)
    when '3'

    when '4'

    when '5'
      sylvain = true
    end
  end until sylvain == true
end

main

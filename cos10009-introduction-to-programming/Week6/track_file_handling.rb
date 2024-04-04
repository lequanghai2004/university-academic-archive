class Track
	attr_accessor :name, :location
	def initialize (name, location)
		@name = name
		@location = location
	end
end

# Returns an array of tracks read from the given file
def read_tracks(music_file)
  music_file = File.new(music_file, "r")
  count = music_file.gets().to_i()
  tracks = Array.new()
  i = 0
  # Put a while loop here which increments an index to read the tracks
  while i < count
    track = read_track(music_file)
    tracks << track
    i += 1
  end
  music_file.close
  return tracks
end

# reads in a single track from the given file.
def read_track(a_file)
	name = a_file.gets
  location = a_file.gets
  track = Track.new(name, location)
  return track
end

def print_tracks(tracks)
  tracks.each do |track|
    print_track(track)   
  end
end

def print_track(track)
  puts(track.name)
	puts(track.location)
end

def main()
  tracks = read_tracks("input.txt")
  print_tracks(tracks)
end

main()


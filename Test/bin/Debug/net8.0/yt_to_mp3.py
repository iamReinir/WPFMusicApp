import os
import pytube
from pytube import YouTube
import sys


def download_audio(id):
    try:
        yt = YouTube(f'https://www.youtube.com/watch?v={id}')
        filename = video_id+".mp4"
        # Get the highest quality audio stream
        audio_stream = yt.streams.filter(file_extension='mp4').order_by('abr').last()

        if audio_stream:
            print(f'Downloading: {filename}...')

            # Download the audio stream
            audio_stream.download(filename=filename)

            print('Download completed!')
            return
        else:
            print('No audio stream available for the given URL.')
            return
    except Exception as e:
        print(f'Error: {str(e)}')
        return       
        
def convert_mp4_to_mp3(mp4_file, mp3_file):
    try:
        os.system(f'ffmpeg -i ./{mp4_file} ./{mp3_file}')     
    except Exception as e:
        print(f'Error: {str(e)}')


# Get the video
video_id = sys.argv[1]

# Display the video details
print("Downloading YouTube video:")
download_audio(video_id)
convert_mp4_to_mp3(video_id + ".mp4", video_id + ".mp3");
os.remove(video_id + ".mp4")

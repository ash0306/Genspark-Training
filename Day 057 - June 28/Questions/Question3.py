# 3) Sort sore and name of players print the top 10

def sort_players(players):
    sorted_players = sorted(players, key=lambda x: (-x['score'], x['name']))
    return sorted_players[:10]

players = [
    {"name": "Aragorn", "score": 50},
    {"name": "Leia", "score": 80},
    {"name": "Gandalf", "score": 70},
    {"name": "Frodo", "score": 60},
    {"name": "Galadriel", "score": 90},
    {"name": "Spock", "score": 70},
    {"name": "Eowyn", "score": 50},
    {"name": "Legolas", "score": 85},
    {"name": "Arwen", "score": 60},
    {"name": "Bilbo", "score": 70},
    {"name": "Ripley", "score": 95},
    {"name": "Yoda", "score": 85}
]

top_10_players = sort_players(players)
for player in top_10_players:
    print(f"{player['name']}: {player['score']}")

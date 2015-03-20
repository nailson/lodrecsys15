
items_music <- read.delim("~/Documentos/Mestrado/Git/lodrecsys15/data/items_music.dat", header=T, quote="")

Musical_artists = items_music[items_music$type!="music_genre",]

newArtists = data.frame( item=substring(Musical_artists$X..id, 3),url=Musical_artists$entity)

newItems = data.frame( item=substring(items_music$X..id, 3),url=items_music$entity)

write.table(newArtists, file="artists_url.tsp", sep="\t", col.names=F, row.names=F, quote=F)

write.table(newItems, file="items_url.tsp", sep="\t", col.names=F, row.names=F, quote=F)

Item_musical_genre = items_music[items_music$type=="music_genre",]

Item_musical_genre = data.frame( item=substring(Item_musical_genre$X..id, 3),url=Item_musical_genre$entity)

user_data = data.frame( user=unique(training_likes_music[order(training_likes_music$V1),]$V1))

user_data$id = c(1:length(user_data$user))

write.table(user_data, file="user_data.tsp", sep="\t", col.names=F, row.names=F, quote=F)

newTraining = merge(training_likes_music, user_data, by.x="V1", by.y="user")
newTraining = data.frame( User=newTraining$id, Item=substring(newTraining$V2,3), weight=rep(1,length(newTraining$V1)) )


write.table(newTraining, file="newTraining.tsp", sep="\t", col.names=F, row.names=F, quote=F)

write.table(user_data, file="MapUserData.tsp", sep="\t", col.names=F, row.names=F, quote=F)

write.table(Item_musical_genre, file="genre_items.tsp", sep="\t", col.names=F, row.names=F, quote=F)


artists_genre <- read.delim("~/Documentos/Mestrado/Git/lodrecsys15/R/Artists/LOD_artists_genre.tsp", header=FALSE)

MapGenres = data.frame( id=c(1:length(unique(artists_genre$V2))), genre = unique(artists_genre$V2) )

write.table(MapGenres, file="MapGenres.tsp", sep="\t", col.names=F, row.names=F, quote=F)

newCategoryFile = merge(artists_genre, MapGenres, by.x="V2", by.y="genre")

newItemGenreFile = data.frame(item=newCategoryFile$V1, genre=newCategoryFile$id)

write.table(newItemGenreFile, file="newItemGenre.tsp", sep="\t", col.names=F, row.names=F, quote=F)

test_set_music <- read.table("~/Documentos/Mestrado/Git/lodrecsys15/data/test_set_music.dat", quote="\"")

merge(test_set_music, user_data, by.x="V1", by.y="user")

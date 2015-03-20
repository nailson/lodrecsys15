
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


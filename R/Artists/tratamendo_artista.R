
tems_music <- read.delim("../../eswc2015-lod-recsys-challenge-v1.0-TRAINING/items_music.dat", header=TRUE)
newArtsts = data.frame( item=substring(tems_music$X..id, 3),url=tems_music$entity)

write.table(newArtsts, file="artists_url.tsp", sep="\t", col.names=F, row.names=F)

user_data = data.frame( user=unique(training_likes_music[order(training_likes_music$V1),]$V1))

user_data$id = c(1:length(user_data$user))

write.table(user_data, file="user_data.tsp", sep="\t", col.names=F, row.names=F)

merge(tems_music, user_data, by.x=tems_music[1], by.y=user_data$user)

select * from player


select * from import_dk_nfl_110622

truncate table player

insert into player 
select 1, 'NFL', [ID], [Name_ID], [TeamAbbrev], '', [Position], [Salary], 0.00, 0.00, 0.00, 0
from IMPORT_DK_NFL_110622

select * from Player

update player set Opponent='ATL' where team='LAC'
update player set Opponent='LAC' where team='ATL'
update player set Opponent='MIA' where team='CHI'
update player set Opponent='CHI' where team='MIA'
update player set Opponent='CIN' where team='CAR'
update player set Opponent='CAR' where team='CIN'
update player set Opponent='GB' where team='DET'
update player set Opponent='DET' where team='GB'
update player set Opponent='IND' where team='NE'
update player set Opponent='NE' where team='IND'
update player set Opponent='NYJ' where team='BUF'
update player set Opponent='BUF' where team='NYJ'
update player set Opponent='LV' where team='JAX'
update player set Opponent='JAX' where team='LV'
update player set Opponent='WAS' where team='MIN'
update player set Opponent='MIN' where team='WAS'
update player set Opponent='ARI' where team='SEA'
update player set Opponent='SEA' where team='ARI'
update player set Opponent='TB' where team='LAR'
update player set Opponent='LAR' where team='TB'
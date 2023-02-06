truncate table nba_stack
truncate table player

select * from Player


insert into player 
select 1, 'NBA', [ID], [Name], [Name_ID], [TeamAbbrev], '', [Position], [Salary], 0.00, 0.00, 0.00, 0, ''
from IMPORT_DK_NBA_020323

update player set PointsPerSalary=FantasyPoints/Salary*1000
update player set PlayerValue=PointsPerSalary
update player set enabled=1 where FantasyPoints > 0

update player set Opponent='POR' where team='WAS'
update player set Opponent='WAS' where team='POR'
update player set Opponent='SAC' where team='IND'
update player set Opponent='IND' where team='SAC'
update player set Opponent='DET' where team='CHA'
update player set Opponent='CHA' where team='DET'
update player set Opponent='PHX' where team='BOS'
update player set Opponent='BOS' where team='PHX'
update player set Opponent='MIN' where team='ORL'
update player set Opponent='ORL' where team='MIN'
update player set Opponent='TOR' where team='HOU'
update player set Opponent='HOU' where team='TOR'
update player set Opponent='SAS' where team='PHI'
update player set Opponent='PHI' where team='SAS'
update player set Opponent='ATL' where team='UTA'
update player set Opponent='UTA' where team='ATL'

delete from NBA_Stack where nba_stackid>21
update player set teamcss = 'background-color: #E03A3E; color: #FDB927;' where team='ATL'
update player set teamcss = 'background-color: #007A33; color: #BA9653;' where team='BOS'
update player set teamcss = 'background-color: #000000; color: #FFFFFF;' where team='BKN'
update player set teamcss = 'background-color: #1D1160; color: #00788C;' where team='CHA'
update player set teamcss = 'background-color: #CE1141; color: #000000;' where team='CHI'
update player set teamcss = 'background-color: #860038; color: #FDBB30;' where team='CLE'
update player set teamcss = 'background-color: #002B5E; color: #B8C4CA;' where team='DAL'
update player set teamcss = 'background-color: #FEC524; color: #0E2240;' where team='DEN'
update player set teamcss = 'background-color: #1D42BA; color: #C8102E;' where team='DET'
update player set teamcss = 'background-color: #FFC72C; color: #1D428A;' where team='GSW'
update player set teamcss = 'background-color: #CE1141; color: #FFFFFF;' where team='HOU'
update player set teamcss = 'background-color: #002D62; color: #FDBB30;' where team='IND'
update player set teamcss = 'background-color: #C8102E; color: #BEC0C2;' where team='LAC'
update player set teamcss = 'background-color: #FDB927; color: #552583;' where team='LAL'
update player set teamcss = 'background-color: #5D76A9; color: #F5B112;' where team='MEM'
update player set teamcss = 'background-color: #98002E; color: #FFFFFF;' where team='MIA'
update player set teamcss = 'background-color: #00471B; color: #EEE1C6;' where team='MIL'
update player set teamcss = 'background-color: #236192; color: #78BE20;' where team='MIN'
update player set teamcss = 'background-color: #0C2340; color: #85714D;' where team='NOP'
update player set teamcss = 'background-color: #006BB6; color: #F58426;' where team='NYK'
update player set teamcss = 'background-color: #007AC1; color: #EF3B24;' where team='OKC'
update player set teamcss = 'background-color: #0077C0; color: #C4CED4;' where team='ORL'
update player set teamcss = 'background-color: #C4CED4; color: #ED174C;' where team='PHI'
update player set teamcss = 'background-color: #1D1160; color: #E56020;' where team='PHX'
update player set teamcss = 'background-color: #E03A3E; color: #000000;' where team='POR'
update player set teamcss = 'background-color: #5A2D81; color: #FFFFFF;' where team='SAC'
update player set teamcss = 'background-color: #C4CED4; color: #000000;' where team='SAS'
update player set teamcss = 'background-color: #CE1141; color: #000000;' where team='TOR'
update player set teamcss = 'background-color: #002B5C; color: #F9A01B;' where team='UTA'
update player set teamcss = 'background-color: #002B5C; color: #E31837;' where team='WAS'

insert into nba_stack values (100,207,90,73,122,89,-1,-1,-1,1)
insert into nba_stack values (100,207,90,73,122,4,-1,-1,-1,1)
insert into nba_stack values (100,91,90,73,122,89,-1,-1,-1,1)
insert into nba_stack values (100,91,90,73,122,27,-1,-1,-1,1)
insert into nba_stack values (100,19,90,73,122,89,-1,-1,-1,1)
insert into nba_stack values (100,19,90,73,122,27,-1,-1,-1,1)
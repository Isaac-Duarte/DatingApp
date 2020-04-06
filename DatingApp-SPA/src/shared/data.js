import { format } from 'date-fns';
import { inputDateFormat } from './constants';
import * as axios from 'axios';

const getHeroes = async function() {
  const response = await axios.get('http://localhost:5000/api/hero/list');
  const heroes = response.data.map(h =>{
    h.origin = format(h.origin, inputDateFormat);
    return h;
  });

  return heroes;
};

const updateHero = async function(hero) {
  await axios({
    method: 'post',
    url: 'http://localhost:5000/api/hero/modify',
    headers: {
      'Authorization': 'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiVXNlciIsInVuaXF1ZV9uYW1lIjoiZm96aWUiLCJuYmYiOjE1ODYxMjgzMjcsImV4cCI6MTU4NjIxNDcyNywiaWF0IjoxNTg2MTI4MzI3fQ.kC2M6jZ2BwX80OjWgjJj-8OHmQBT6dhZmf9DPfrn7rf3Fm_v6Slm8HjfTai-jvGVJo-F7o9RCf6ZQLOyX70awg'
    },
    data: {
      Id: hero.id,
      FirstName: hero.firstName,
      LastName: hero.lastName,
      Origin: hero.origin,
      Capes: Number(hero.capes),
      Description: hero.description
    }
  });
};

export const data = {
  getHeroes,
  updateHero,
};

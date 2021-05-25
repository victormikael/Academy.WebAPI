# academyapi
A Simple API for Data Science Academy

Install Entity Framework Core-CLI:<br>
<code>dotnet tool install --global dotnet-ef</code>

Run command to apply migrations:<br>
<code>dotnet ef database update</code><br>

<hr>

<h3>Endpoints documentation:</h3><br>

<p><b>POST: /api/course</b><br>
# Create a new course.</p>

<p>Request body:</p>
<code>
{ 
  "id": 0,
  "name": "string",
  "active": true,
  "price": 0, 
  "duration": "string",
  "certified": "string"
}
</code>

<h5>Responses</h5>

201 | Created<br>
400 | Bad Request<br>

<hr>

<p><b>GET: /api/course/{id}</b><br>
# Get an course by id.</p>

<p>Request id via route:</p>
<code>/api/course/5</code>

<h5>Responses</h5>

200 | Success<br>
400 | Bad Request<br>
404 | Not Found<br>

<hr>

<p><b>PUT: /api/course/{id}</b><br>
# Update a existing course.</p>

<p>Request id via route:</p>
<code>/api/course/5</code><br><br>

<p>Request body:</p>
<code>
{ 
  "id": 0,
  "name": "string",
  "active": true,
  "price": 0, 
  "duration": "string",
  "certified": "string"
}
</code>

<h5>Responses</h5>

200 | Success<br>
400 | Bad Request<br>
404 | Not Found<br>

<hr>

<p><b>PATCH: /api/course/{id}</b><br>
# Partial update a existing course.</p>

<p>Request id via route:</p>
<code>/api/course/5</code><br><br>

<p>Request body:</p>
<code>
{ 
  "name": "string",
  "active": true,
  "price": 0, 
  "duration": "string",
  "certified": "string"
}
</code><br><br>

<p>Sample exemple request</p>
<code>
{
   "active": 1,
   "price": 1999,
   "duration": "55 hours"
}
</code>

<h5>Responses</h5>

200 | Success<br>
400 | Bad Request<br>
404 | Not Found<br>

<hr>

<p><b>DELETE: /api/course/{id}</b><br>
# Deletes a specific course.</p>

<p>Request id via route:</p>
<code>/api/course/5</code>

<h5>Responses</h5>

200 | Success<br>
400 | Bad Request<br>
404 | Not Found<br>

<hr>

<p><b>GET: /api/course/search/{name}</b><br>
# Get courses by name.</p>

<p>Request name via route:</p>
<code>/api/course/search/developer</code>

<h5>Responses</h5>

200 | Success<br>
204 | No Content<br>
400 | Bad Request<br>

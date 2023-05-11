class HomeIndex extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            latestPosts: []
        };
    }

    componentDidMount() {
        fetch('/api/posts/latest')
            .then(response => response.json())
            .then(data => this.setState({ latestPosts: data }));
    }

    render() {
        return (
            <div className="container">
                <div className="row justify-content-center align-items-center">
                    <div className="col-md-6 text-center">
                        <h1>Learn and Share</h1>
                        <p className="lead">Join our community and start learning and sharing knowledge today.</p>
                        <form action="/search" method="POST" className="mb-4">
                            <div className="input-group">
                                <input type="text" className="form-control" placeholder="Search..." />
                                <span className="input-group-btn">
                                    <button className="btn btn-primary" type="submit">Search</button>
                                </span>
                            </div>
                        </form>
                    </div>
                    <div className="col-md-6">
                        <h2>Latest Posts</h2>
                        <hr />
                        <ul className="list-unstyled">
                            {this.state.latestPosts.map(post => (
                                <li key={post.id}>
                                    <h3>
                                        <a href={`/post/${post.id}`}>{post.title}</a>
                                    </h3>
                                    <p className="post-info">
                                        {post.repliesCount > 0 ?
                                            <span>{post.repliesCount} replies</span> :
                                            <span>No replies</span>
                                        }
                                        <span className="postUser">
                                            <a href={`/profile/${post.authorId}`}>{post.authorName}</a>
                                        </span>
                                    </p>
                                </li>
                            ))}
                        </ul>
                        <div className="text-right">
                            <a href="/post/list">See all posts</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

ReactDOM.render(
    <HomeIndex />,
    document.getElementById('root')
);
